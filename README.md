# Simple Backup

A Windows Explorer Context Menu extension to backup and restore folders to temporary storage.

[![Build state](https://travis-ci.org/UweKeim/SimpleBackup.svg?branch=master)](https://travis-ci.org/UweKeim/SimpleBackup "Travis CI build status")

## Introduction

For testing purposes of our [CMS](http://www.zeta-producer.com) I often do the following steps:

1. Copy a whole folder from somewhere onto my local PC.
1. Do some (modifying) operations on this folder (during my tests).
1. Delete the folder (after the tests).
1. Start from item 1.

To simplify steps 3. and 4., I developed this Simple Backup extensions.

## Using the application

The application consists of one single executable file. Download the file and double-click it to install.

You're done! 

There are now two new context menu entries "Backup" and "Restore" when you right-click a _folder_ in Windows Explorer:

- The "Backup" option creates a backup.
- The "Restore" copies back a previously created backup.

To uninstall, go to Windows Control Panel and select "Simple Backup".

## History

  * *2009-11-25* - First release to GitHub.
