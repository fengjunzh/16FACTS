from lxml import etree
import os

CDC_Address = r'\\cdcnas01\STS_CATS\CatsResultTransferTool'
SDC_Address = r'\\sdcnas01\STS_CATS\CatsResultTransferTool'
ASZ_Address = r'\\asz-42jc23x\CatsResultTransferTool'


def get_solution_path():
    path = os.path.dirname(__file__)
    output_path = os.path.join(path, "Output")
    components_path = os.path.join(output_path, "Components.xml")
    server_path = os.path.join(output_path, "ServerVersion.xml")
    with open(server_path, 'rb') as f:
        doc = etree.fromstring(f.read())
        version = doc.find('ServerVersion').text
    version_path = os.path.join(output_path, 'Version' + version)
    configuration_path = os.path.join(version_path, 'Cfg', 'Server.xml')
    return configuration_path, components_path


def update_app_server(file_path, server_address):
    with open(file_path, 'rb') as f:
        doc = etree.fromstring(f.read())
        doc.find('Address').text = server_address
    with open(file_path, 'wb') as f:
        f.write(etree.tostring(doc, pretty_print=True))


def update_components_path(file_path, server_address):
    with open(file_path, 'rb') as f:
        doc = etree.fromstring(f.read())
        doc.find('.//Server').text = server_address
    with open(file_path, 'wb') as f:
        f.write(etree.tostring(doc, pretty_print=True))


def welcome():
    print('Please select target server')
    print('1.CDC')
    print('2.SDC')
    print('3.ASZ')


def entry():
    while True:
        welcome()
        arg = input('>>>')
        if arg == '1':
            server_address = CDC_Address
            break
        if arg == '2':
            server_address = SDC_Address
            break
        if arg == '3':
            server_address = ASZ_Address
            break
    configuration_path, components_path = get_solution_path()
    update_app_server(configuration_path, server_address)
    update_components_path(components_path, server_address)


entry()
