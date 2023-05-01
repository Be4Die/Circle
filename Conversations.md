# 📜Conversations.

## 📋Naming Conversations.
 - global CamelCase.
 - private m_CamelCase.
 - interfaces ICamelCase.
## 📂Folder structure
[References](https://unity.com/how-to/organizing-your-project) - unity guide (Example 2 with small changes).

Current Scructure:

    -Assets
    
    --Art
    ---Materials
    ---Music
    ---Prefabs # not prefabs thats used in code
    ---Sound
    ---Sprites
    ---Textures
    ---UI
    
    --Levels
    ---Development # levels wich used only for dev
    ---Productions # levels wich used only production
    --Settings # global settings files for unity
    ---Scenes # specific settings for scenes
    
    --Src # source files
    ---Framework # all files used in game framework
    ---Shaders # like hlsl or shader-graps
     
    --ThirdParty # all third-party assets