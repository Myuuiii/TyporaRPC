# TyporaRPC

A simple, still command line, application that will add Discord Rich Presence to Typora!

## What it looks like

### Not editing a file:

This will likely only occur when you start Typora without having a file open, once you type one character the title will change to "Untitled.md".

![](https://cdn.mutedevs.nl/myuuiii/github/typorarpc/not_editing.png)

### Editing a file:

#### Saved

![](https://cdn.mutedevs.nl/myuuiii/github/typorarpc/edit_saved.png)

#### Unsaved

![](https://cdn.mutedevs.nl/myuuiii/github/typorarpc/edit_unsaved.png)

## Installation

1. Download the latest release from the [GitHub releases page](https://github.com/Myuuiii/TyporaRPC/releases) *or* compile your own binary files.
2. Run the .exe or .dll to start

## What about setting up TyporaRPC as a service?

I've tried to install TyporaRPC through NSSM, the way I tried this caused the service to not start, or at least, not connect to the Discord client. Here is a way you could try installing it as a service:

I recommend using NSSM to set up a service since it is easy to manage. You can install NSSM using Chocolatey. 

```bash
choco install nssm
```

Using an **elevated** terminal, run the command 

```bash
nssm install TyporaRPC
```

This will open a dialogue where you will have to point to the .exe of TyporaRPC, I recommend placing the TyporaRPC exe file in a place where you will not have to move it, since moving the file will break the service. 

After you close this dialogue the service will be installed and TyporaRPC will automatically start on system start-up.

You can start the service directly by running:

```bash
nssm start TyporaRPC
```

## Customization

There currently is no way to customize TyporaRPC.