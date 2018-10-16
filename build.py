import re
import sys
import argparse
import subprocess

parser = argparse.ArgumentParser(add_help=True)
parser.add_argument('--git',          action='store_true', dest='git',          help='Use git to release builded project')
parser.add_argument('--unity',        action='store',      dest='unity',        help='Path to Unity folder')
parser.add_argument('--new_version',  action='store_true', dest='new_version',  help='Create release as new version')

args = parser.parse_args()

unity_path = r"C:\Program Files\Unity\Editor\Unity.exe"
if args.unity:
    unity_path = args.unity

build_cmd = [unity_path, "-quit", "-batchmode", "-executeMethod", "ProjectBuilder.PerformBuild"]
build_proc = subprocess.Popen(build_cmd).communicate()

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
    
    with open(r'./Wild West/ProjectSettings/ProjectSettings.asset', 'r') as f:
        settings = f.read()
    
    with open(r'./Wild West/ProjectSettings/ProjectSettings.asset', 'w') as f:
        settings = re.sub(r'bundleVersion: \d\d\.\d\d\d', 'bundleVersion: {}.{}'.format(new_version, new_build), settings)
        f.write(settings)
    
    add_cmd = ["git", "add", "."]
    subprocess.Popen(add_cmd).communicate()

    commit_cmd = ["git", "commit", "-m", "auto_build"]
    subprocess.Popen(commit_cmd).communicate()

    new_tag_cmd = ["git", "tag", release_tag]
    subprocess.Popen(new_tag_cmd).communicate()

    push_cmd = ["git", "push", "--follow-tags"]
    subprocess.Popen(push_cmd).communicate()



