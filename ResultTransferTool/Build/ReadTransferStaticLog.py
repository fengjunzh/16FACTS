from datetime import date, timedelta
import os
import xml.etree.cElementTree as Etree

RootPath = os.path.join("\\\\asz-42jc23x", "CatsClientTransferStatics")
today = date.today()
yesterday = today - timedelta(1)


def convert_date_label_to_string(date_label):
    return str(date_label.year) + "-" + str(date_label.month) + "-" + str(date_label.day)


def get_yesterday_label():
    return convert_date_label_to_string(yesterday)


def get_date_offset_label(offset):
    day = today - timedelta(offset)
    return convert_date_label_to_string(day)


def get_today_label():
    return convert_date_label_to_string(today)


def get_files(date_label):
    path = os.path.join(RootPath, date_label)
    return os.listdir(path)


def get_pc_with_error_dat(date_label):
    files = get_files(date_label)
    return get__error_dat(files, date_label)


def get_pc_name(file_name, date_label):
    return file_name.replace("_" + date_label, "").replace(".xml", "")


def get__error_dat(file_names, date_label):
    output = {}
    for fileName in file_names:
        file_path = os.path.join(RootPath, date_label, fileName)
        pc_name = get_pc_name(fileName, date_label)
        output[pc_name] = get_error_dat_from_xml(file_path)
    return output


def get_error_dat_from_xml(file_path):
    output = {'Timeout': []}
    xml_tree = Etree.parse(file_path)
    root = xml_tree.getroot()
    error = root.find('Failure')
    files = error.findall('file')
    for file in files:
        #if 'Timeout expired' in file.get('errorMessage'):
        output['Timeout'].append(file.get('name'))
    return output
