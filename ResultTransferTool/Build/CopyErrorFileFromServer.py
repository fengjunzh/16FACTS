import shutil
import os
import ReadTransferStaticLog
from datetime import date, timedelta
import ntpath

WorkingDirectory, _ = os.path.split(__file__)
RootPath = os.path.join("\\\\asz-42jc23x", "CatsResultErrorFileCopy")
TargetRootPath = os.path.join(WorkingDirectory, "Output", "Version1.0", "Results")


def get_error_info(offset):
    offset_label = ReadTransferStaticLog.get_date_offset_label(offset)
    return ReadTransferStaticLog.get_pc_with_error_dat(offset_label)


def get_date_label(offset):
    today = date.today()
    offset_date = today - timedelta(offset)
    return offset_date.isoformat()


def build_error_file_path(error_info, date_label):
    output = []
    for pc_name, v in error_info.items():
        for errorTag, files in v.items():
            for file in files:
                path = os.path.join(RootPath, date_label, pc_name, file)
                output.append(path)
    return output


def copy_error_file(offset):
    date_label = get_date_label(offset)
    error_info = get_error_info(offset)
    files = build_error_file_path(error_info, date_label)
    for file in files:
        file_name = ntpath.basename(file)
        target_path = os.path.join(TargetRootPath, file_name)
        shutil.copy(file, target_path)
        print("Copy file: ", file_name)
    print("Total {0} files are copied".format(len(files)))


print('Please input the day offset before today')
input_offset = int(input('>>> '))
copy_error_file(input_offset)
print('Press any key to exit')
input()
