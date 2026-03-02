# Download MSBuild 2015 from https://www.microsoft.com/en-us/download/details.aspx?id=48159

import os, subprocess
import shutil
import xml.etree.cElementTree as ET


def GetHardCodedVersion():
    versionFile = os.path.join(slnDirectory, "ResultTransferTool", "VersionConstant.cs")
    file = open(versionFile, 'r')
    lines = file.readlines()
    for line in lines:
        newline = line.replace(" ", "")
        if "BinaryVersion=" in newline:
            return newline[newline.index("BinaryVersion=") + len("BinaryVersion="):newline.index(";")]


print("****** Initialization ******")
workingDirectory, _ = os.path.split(__file__)

print("****** Build Result Transfer Tool ******")
slnDirectory, _ = os.path.split(workingDirectory)
sln = os.path.join(slnDirectory, "ResultTransferTool.sln")
# msbuild = r'C:\Program Files (x86)\MSBuild\14.0\Bin\amd64\msbuild.exe'
msbuild = r'C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe'
arg1 = '/p:Configuration=Release'
arg2 = '/p:Platform=x86'
subprocess.call([msbuild, sln, arg1, arg2])

print("****** Copy Result Transfer tool files ******")
outputDirectory = os.path.join(workingDirectory, "Output")
releaseDirectory = os.path.join(outputDirectory, "Version" + GetHardCodedVersion())
if os.path.exists(releaseDirectory):
    shutil.rmtree(releaseDirectory)
os.makedirs(releaseDirectory)
vsOutputDirectory = os.path.join(slnDirectory, "ResultTransferGUI", "bin", "x86", "Release")
fileNames = ["CATS.BLL.dll", "CATS.DAL.dll", "CATS.Model.dll", "Encryptor.dll", "Nlogger.dll", "ResultTransferGUI.exe",
             "ResultTransferTool.dll"]
directories = ["Cfg", "logo"]
for fileName in fileNames:
    srcPath = os.path.join(vsOutputDirectory, fileName)
    targetPath = os.path.join(releaseDirectory, fileName)
    shutil.copy(srcPath, targetPath)
for directory in directories:
    srcPath = os.path.join(vsOutputDirectory, directory)
    targetPath = os.path.join(releaseDirectory, directory)
    shutil.copytree(srcPath, targetPath)
srcPath = os.path.join(vsOutputDirectory, "Cfg", "Workstation.xml")
targetPath = os.path.join(outputDirectory, "Workstation.xml")
shutil.copy(srcPath, targetPath)

print("****** Copy Updater files ******")
os.makedirs(os.path.join(releaseDirectory, "Updater"))
srcUpdaterPath = os.path.join(slnDirectory, "Updater", "bin", "x86", "Release")
srcPath = os.path.join(srcUpdaterPath, "Updater.exe")
targetPath = os.path.join(releaseDirectory, "Updater", "Updater.exe")
shutil.copy(srcPath, targetPath)
targetPath = os.path.join(outputDirectory, "Updater.exe")
shutil.copy(srcPath, targetPath)
srcPath = os.path.join(srcUpdaterPath, "Configuration")
targetPath = os.path.join(releaseDirectory, "Updater", "Configuration")
shutil.copytree(srcPath, targetPath)

print("****** Copy configuration files ******")
srcPath = os.path.join(releaseDirectory, "Updater", "Configuration", "Components.xml")
tree = ET.parse(srcPath)
root = tree.getroot()
for rank in root.iter("VersionSubFolder"):
    rank.text = "Version" + GetHardCodedVersion()
tree.write(srcPath)
targetPath = os.path.join(outputDirectory, "Components.xml")
shutil.copy(srcPath, targetPath)

serverVersionPath = os.path.join(workingDirectory, "ServerVersion.xml")
tree = ET.parse(serverVersionPath)
root = tree.getroot()
for rank in root.iter("ServerVersion"):
    rank.text = GetHardCodedVersion()
targetPath = os.path.join(outputDirectory, "ServerVersion.xml")
tree.write(targetPath)

print("****** Build Process Check ******")
processCheckFolder = os.path.join(os.path.split(slnDirectory)[0], "ProcessCheck")
processCheckSln = os.path.join(processCheckFolder, "ProcessCheck.sln")
subprocess.call([msbuild, processCheckSln, arg1, arg2])
processCheckOutputFolder = os.path.join(processCheckFolder, "ProcessCheckHost", "bin", "x86", "Release")
processCheckFiles = ["ProcessCheck.dll", "ProcessCheckHost.exe"]
for fileName in processCheckFiles:
    srcPath = os.path.join(processCheckOutputFolder, fileName)
    targetPath = os.path.join(releaseDirectory, fileName)
    shutil.copy(srcPath, targetPath)
