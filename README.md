# blenderRenderSrv
A lan TCP based server and client WinForms Application that transfers .blend files from the client to server and automatically renders them  
<img title="a title" alt="Alt text" src="https://github.com/VisualPlate/blenderRenderSrv/blob/master/heroimg.webp?raw=true">

## Key Features
- Easy to Setup and Use
- Very Lightweight (only 20mb ram)
- Up to 40% more faster render times*

*With lower end device running on Headless Mode. Difference is visible especially on high memory scenes

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
