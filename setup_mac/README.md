# Development
- Sourcetree
- Docker
- XCode
- Rider
- DataGrip
- NoSQL Workbench
- Proxyman
- Postman

# Other
- GoTiengViet
- CleanMyMac X

# Shell
## [Rosetta 2](#)
An emulator that allows us to run apps that use x86 instructions, the instruction set used by Intel chips, on ARM
```sh
/usr/sbin/softwareupdate --install-rosetta --agree-to-license
```

## [Homebrew](https://brew.sh/) 
Use to install most of our apps and utilities
```sh
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```

## Tools
Clone the repo [here](https://github.com/minhnd410/dotfiles)

- To Check if file is executable `ls -al`
- To make it executable `chmod +x brew-installs.sh`

## [iTerm2](https://iterm2.com/) 
iTerm2 is a replacement for Terminal

## [Oh My Zsh](https://github.com/ohmyzsh/ohmyzsh) 
Oh My Zsh is an open source, community-driven framework for managing your zsh configuration.
```sh
sh -c "$(curl -fsSL https://raw.githubusercontent.com/ohmyzsh/ohmyzsh/master/tools/install.sh)"
```

## [powerlevel10k](https://github.com/romkatv/powerlevel10k)
Powerlevel10k is a theme for Zsh. It emphasizes speed, flexibility and out-of-the-box experience.

## [zsh-autosuggestions](https://github.com/zsh-users/zsh-autosuggestions) 
It suggests commands as you type based on history and completions.

```sh
git clone https://github.com/zsh-users/zsh-autosuggestions ${ZSH_CUSTOM:-~/.oh-my-zsh/custom}/plugins/zsh-autosuggestions
```
Add the plugin to the list of plugins for Oh My Zsh to load (inside `~/.zshrc`)
```sh
nano ~/.zshrc
plugins=(git zsh-autosuggestions)
```
Start a new terminal session.

## [zsh-syntax-highlighting](https://github.com/zsh-users/zsh-syntax-highlighting)

Activate the plugin in `~/.zshrc`:
```sh
plugins=(git zsh-autosuggestions zsh-syntax-highlighting)
```

Start a new terminal session.

## [nvm](https://github.com/nvm-sh/nvm)
```sh
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.37.2/install.sh | bash
```

Append the following lines to your `.zshrc` file

```ssh
export NVM_DIR="$HOME/.nvm"
#This loads nvm
[ -s "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh"
#This loads nvm bash_completion
[ -s "$NVM_DIR/bash_completion" ] && \. "$NVM_DIR/bash_completion"
```

```ssh
nvm --version
```

## [Git](#)
To config Git
```ssh
git config --global user.name < USERNAME > &&
git config --global user.email < EMAIL > &&
git config --global --list
```
## [Github CLI](https://cli.github.com/)
## [VSCode](https://code.visualstudio.com/)
- Shift + Command + P
- Find `Install "code" command in PATH`

## [Powerline Fonts](https://github.com/powerline/fonts)
Most themes in Oh My Zsh require Powerline Fonts.
```sh
git clone https://github.com/powerline/fonts.git --depth=1 &&
cd fonts &&
./install.sh &&
cd ..
```