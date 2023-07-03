"""
       _   _ _           
 /\ /\| |_(_) | ___  ___ 
/ / \ \ __| | |/ _ \/ __|
\ \_/ / |_| | |  __/\__ |
 \___/ \__|_|_|\___||___/
                         
This is a utilies item
Dont delete this, this is to be run from a local clone for the "All Commands" html file

Also this was made by Chat GiPiTy but modified to fit the use
"""

from bs4 import BeautifulSoup

# Read the HTML data from a file
with open('all_commands.html', 'r') as file:
    html = file.read()

soup = BeautifulSoup(html, 'html.parser')

# Create a new text file for writing
output_filename = 'all_commands.txt'
with open(output_filename, 'w') as output_file:
    # Write the heading to the file
    output_file.write("MC (MentalCrash) Docs\n\n")
    
    for command_div in soup.find_all('div', class_='command'):
        command_name = command_div.find('h2').text.strip()
        command_description = command_div.find('h3').text.strip()
        command_long_description = command_div.find('p').text.strip()
        command_code = command_div.find('code').text.strip()
        
        # Write the extracted data to the text file
        output_file.write(command_name + '\n')
        output_file.write(command_description + '\n')
        output_file.write(command_long_description + '\n')
        output_file.write(command_code + '\n')
        output_file.write('\n')
