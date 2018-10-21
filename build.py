import re
import os
import sys
import argparse
import subprocess

def script_run():
     # Read main info for building
    parser = argparse.ArgumentParser(add_help=True)
    parser.add_argument('--git',          action='store_true', dest='git',          help='Use git to release builded project')
    parser.add_argument('--unity',        action='store',      dest='unity',        help='Path to Unity folder')
    parser.add_argument('--new_version',  action='store_true', dest='new_version',  help='Create release as new version')
    args = parser.parse_args()

    # Set main paths
    if args.unity:
        unity_path = args.unity
    else:
        win_unity_path = r'C:\Program Files\Unity\Editor\Unity.exe'.split('\\')
        unity_path = os.path.join(*win_unity_path)
  
    ww_apk_path = ['.', 'Wild West', 'WildWest.apk']
    if os.path.exists(os.path.join(*ww_apk_path)):
        os.remove(os.path.join(*ww_apk_path))

    # Start building
    print("Building start...")
    build_cmd = [unity_path, "-quit", "-batchmode", "-logfile", "buildlog.tmp", "-executeMethod", "ProjectBuilder.PerformBuild"]
    build_proc = subprocess.Popen(build_cmd).communicate()

    if os.path.exists(os.path.join(*ww_apk_path)):
        print("Build completed successfully!")
    else:
        print("Build failed!")
        exit(-1)

    # Work with git: add files to git
    if args.git:
        tag_cmd = ["git", "tag"]
        tag_proc = subprocess.Popen(tag_cmd, stdout=subprocess.PIPE)
        output, _ = tag_proc.communicate()
        
        output = output.decode('utf-8')
        output = re.findall(r'RELEASE_\d\d_\d\d\d', output)
        
        last_version = re.findall(r'RELEASE_(\d\d)_\d\d\d', output[-1])[0]
        last_build   = re.findall(r'RELEASE_\d\d_(\d\d\d)', output[-1])[0]

        if args.new_version:
            new_version = '{0:02d}'.format(int(last_version) + 1)
            new_build   = '000'
        else:
            new_version = last_version
            new_build   = '{0:03d}'.format(int(last_build) + 1)

        release_tag = 'RELEASE_{}_{}'.format(new_version, new_build)
        
        settings_path = r'./Wild West/ProjectSettings/ProjectSettings.asset'.split('/')
        with open(os.path.join(*settings_path), 'r') as f:
            settings = f.read()
        
        with open(os.path.join(*settings_path), 'w') as f:
            settings = re.sub(r'bundleVersion: \d\d\.\d\d\d', 'bundleVersion: {}.{}'.format(new_version, new_build), settings)
            f.write(settings)
        print("Version file updated!")

        add_cmd = ["git", "add", "."]
        subprocess.Popen(add_cmd).communicate()
        print("GIT: Files added!")

        commit_cmd = ["git", "commit", "-m", "auto_build"]
        subprocess.Popen(commit_cmd).communicate()
        print("GIT: Files commited!")

        new_tag_cmd = ["git", "tag", release_tag]
        subprocess.Popen(new_tag_cmd).communicate()
        print("GIT: Tag created!")

        push_cmd = ["git", "push"]
        subprocess.Popen(push_cmd).communicate()
        print("GIT: Commit pushed!")

        push_tag_cmd = ["git", "push", "origin", release_tag]
        subprocess.Popen(push_tag_cmd).communicate()
        print("GIT: Tag pushed!")


if __name__ == '__main__':
   script_run()