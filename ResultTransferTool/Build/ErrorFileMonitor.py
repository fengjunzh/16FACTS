from datetime import date, timedelta, datetime
import os
import pickle
import shutil
import time


WorkingDirectory, _ = os.path.split(__file__)
RootPath = os.path.join("\\\\asz-42jc23x", "CatsResultErrorFileCopy")
TargetRootPath = os.path.join(WorkingDirectory, "Results")
today = date.today()
yesterday = today - timedelta(1)
monitor_folder_today = os.path.join(RootPath, today.isoformat())
monitor_folder_yesterday = os.path.join(RootPath, yesterday.isoformat())

def run(monitor_folder,pickle_file_name):
    if os.path.exists(monitor_folder) is False:
        return
    pc_folders = os.listdir(monitor_folder)
    files_fresh = {}
    for pc_folder in pc_folders:
        folder_path = os.path.join(monitor_folder, pc_folder)
        files = os.listdir(folder_path)
        files_fresh[pc_folder] = files

 #   pickle_file_name = "fileCache.p"
    if os.path.exists(pickle_file_name):
        files_in_cache = pickle.load(open(pickle_file_name, "rb"))
        files_diff = {}

        for pc, files in files_fresh.items():
            if pc in files_in_cache:
                files_new = [i for i in files if i not in files_in_cache[pc]]
                if len(files_new)!=0:
                    files_diff[pc] = files_new
            else:
                files_diff[pc] = files

        if len(files_diff)!=0:
            pickle.dump(files_fresh, open(pickle_file_name, "wb"))
    else:
        pickle.dump(files_fresh, open(pickle_file_name, "wb"))
        files_diff = files_fresh

    for pc, names in files_diff.items():
        if pc == "ASZ-42JC23X":
            continue
        for name in names:
            source_path = os.path.join(monitor_folder, pc, name)
            target_path = os.path.join(TargetRootPath, name)
            print(name)
            shutil.copy(source_path, target_path)

while True:
    print(datetime.now())
    run(monitor_folder_yesterday,"yesterday_cache.p")
    run(monitor_folder_today,"today_cache.p")
    time.sleep(30)
