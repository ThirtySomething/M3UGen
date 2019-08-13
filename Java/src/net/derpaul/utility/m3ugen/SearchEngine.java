package net.derpaul.utility.m3ugen;

import java.io.File;

/**
 * @author Jochen Paul
 * @version 1.0
 * @see java.lang.Object
 */
public class SearchEngine extends Object {

    /**
     * Counter for the generated playlists.
     *
     * @since 1.0
     */
    private int intPlayListCounter;

    /**
     * Directory where to start from
     *
     * @since 1.0
     */
    private final String strBaseDir;

    /**
     * With the creation of an object the recursive search will be started.
     *
     * @param strRootDirectory Name of the directory where to start the search.
     * @since 1.0
     * @see java.lang.String
     */
    public SearchEngine(String strRootDirectory) {
        this.intPlayListCounter = 0;
        this.strBaseDir = strRootDirectory;
    }

    /**
     * Examine the given pathname. In the case of a directory, manage this
     * directory.
     *
     * @param strFileName Name of the directory to analyze.
     * @since 1.0
     * @see java.lang.String
     */
    public void analyzePath(String strFileName) {
        java.io.File objFileCurrentElement;

        objFileCurrentElement = new java.io.File(strFileName);

        if (objFileCurrentElement.isDirectory()) {
            this.handleDir(objFileCurrentElement);
        }
    }

    /**
     * Explore all mp3-files in this directory and create a playlist-file. After
     * that call analyzePath for all directories found.
     *
     * @param objFileCurrentDirectory Name of the directory to manage.
     * @since 1.0
     * @see java.io.File
     */
    public void handleDir(java.io.File objFileCurrentDirectory) {
        MP3Filter objMP3Filter;
        M3UPlaylist objM3UPlaylist;
        java.io.File[] arrFileList;

        objMP3Filter = new MP3Filter(GUIMain.strExtensionMP3);
        arrFileList = objFileCurrentDirectory.listFiles(objMP3Filter);

        if (arrFileList.length > 0) {
            objM3UPlaylist = new M3UPlaylist(arrFileList);
            objM3UPlaylist.createPlayList();
            this.intPlayListCounter++;
        }

        arrFileList = objFileCurrentDirectory.listFiles();
        for (File objFile : arrFileList) {
            this.analyzePath(objFile.getAbsolutePath());
        }
    }

    /**
     * Create recursive play lists started from base dir
     *
     * @return String
     */
    public String startSearch() {
        String rcValue;

        rcValue = null;

        if ((this.strBaseDir != null) && (this.strBaseDir.length() > 0)) {
            this.analyzePath(this.strBaseDir);
            if (this.intPlayListCounter > 0) {
                rcValue = this.intPlayListCounter + " playlist(s) created...";
            } else {
                rcValue = "No '" + GUIMain.strExtensionMP3 + "'-files found in " + this.strBaseDir + "...";
            }
        }
        
        return rcValue;
    }

}
