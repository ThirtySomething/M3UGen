# M3UGen #

This is the version in Java.

## Prerequisites ##

There will be some utilities required.

- [Netbeans](https://netbeans.org/ "Netbeans IDE") to compile the source and build the jar file.
- [launch4j](http://launch4j.sourceforge.net/ "launch4j") to wrap the jar file to an executeable.
- [NSIS Installer](http://nsis.sourceforge.net/Main_Page "NSIS Installer") to create a simple installer for `M3UGenNG`.

## Create the jar file ##
Just open the `M3UGen`-project in Netbeans and run `Clean and Build` from the context menue. If everything was correct, you'll find `M3UGen.jar` in the `setup` directory.

## Create wrapper for jar file ##
Two simple steps:

- Open `M3UGen_Launch4j.xml` in your favourite editor, adjust the paths in `<jar>` and `<outfile>` to match your reqirements.
- Start `launch4j`, load mentioned file and create the wrapper.

Check manually the existence of `M3UGen.exe` in the `setup` directory.

## Create setup for M3UGen ##

Nothing complicated - compile the `M3UGen_NSIS.nsi` with the `Compile NSIS Script` of the context menue. You'll get an `M3UGen_Setup.exe` in the `setup` directory.
