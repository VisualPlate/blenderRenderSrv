# blenderRenderSrv
A lan TCP based server and client WinForms Application that transfers .blend files from the client to server and automatically renders them  
<img title="a title" alt="Alt text" src="https://github.com/VisualPlate/blenderRenderSrv/blob/master/heroimg.webp?raw=true">

## Key Features
- Easy to Setup and Use
- Very Lightweight (only 20mb ram)
- Up to 40% more faster render times*

*With lower end device running on Headless Mode. Difference is visible especially on high memory scenes

## Disclaimer
This is barebone version and doesnt include any security, authentication or error checking features. It is recommended to use this only in private lan without port forwarding any IPs when using this for security reasons

## Before use Make sure to:
- Have atleast the same or higher version of blender in the server
- Be on the same network or on other TCP compatible way
- Have only ONE frame in one frame images as this application can handle animations/images sequence as well
- Have copied autorender.py file to C:/users/NAME/documents folder from server/depencencies

## Why?
- To make rendering and Blender usage more effient by using other PC resources
- To automate the whole process of rendering high amount of image sequences, but keeping peformance on main device

*Peformance tested in Headless Mode running Windows with:  
** 8th i5 with iGPU and 8gb ram | 10-40% faster  
** 11th i7 with iGPU and 16gb ram | 15-20% faster   
** 12th i5 with 6gb rtx 3050 and 16gb ram | 5-7% faster  

# DOCS
## Usage General
- Keep in mind that the server needs to have listener on before client sending
- Download autorun.py and brsSrv_vX-XX.exe to server
- Download brsClient_vX-XX.exe to the client
  
## Usage Server
- Make sure to copy or move autorender.py to C:\users\CURRENTUSER\documents folder. 
1. Give the server a hosting port
2. Give the server the blender.exe path using "\\", not "/"
3. Click Start Listerner

## Usage Client
- Give the client the servers: IPv4 and the server port
- Choose a valid .Blend file with a camera in the .blend file
- Click Send

