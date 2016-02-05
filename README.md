
# CherryTree
This repo contains some Unity scripts that are simple and easy for others to leverage. All scripts are being written with the latest Unity 5 and may or may not work in earlier versions.

## Cherries
Mainly there are 3 types of cherries, i.e. Property, Runtime, and Editor. The Property cherries contain the custom attribute and editor for property in the inspector tab. The Runtime cherries can be used in run-time while the Editor cherries can be used to extend the functionality of Unity Editor.

### Main

| Name | Description | Dependency |
|---|---|---|
| chConstant | Contains several Unity constans |   |
| ... | still growing | ... |

### Property

#### chPropertyAttribute
Custom attribute

| Name | Description | Dependency |
|---|---|---|
| chTagSelectorAttribute | Unity tag selector attribute |   |
| ... | still growing | ... |

#### chPropertyDrawer
Custom property drawer

| Name | Description | Dependency |
|---|---|---|
| chTagSelectorPropertyDrawer | Unity tag selector property drawer | chTagSelectorAttribute, chConstant |
| ... | still growing | ... |

### Runtime
| Name | Description | Dependency |
|---|---|---|
| chAudioLoader | Load inputted AudioClips by using chDict |   |
| chAudioSource | Controlling AudioSource component where this script is attached |   |
| chAudioPlayer | Combine chAudioSource and chAudioLoader | chAudioLoader, chAudioSource |
| chAudioManager | Manage several chAudioPlayers by Unity tags | chAudioPlayer, chPropertyAttribute, chPropertyDrawer, chConstant | 
| ... | still growing | ... |

### Editor 
| Name | Description |
|---|---|---|
| ... | still growing | ... | 

## Usage
Simply clone the repository and open it with Unity.
When you do cherry picking please note that some features may depend on others.

## Message
Please help me to grow this CherryTree with your comments, suggestions, and critics.
