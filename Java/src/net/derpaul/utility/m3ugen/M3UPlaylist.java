package net.derpaul.utility.m3ugen;

import java.io.File;

/**
 * @author Jochen Paul
 * @version 1.0
 * @see java.lang.Object
 */
public class M3UPlaylist extends Object {

    /**
     * The name of the physical file to be generated.
     *
     * @since 1.0
     * @see java.lang.String
     */
    protected String strPlayListName;

    /**
     * Array containing the names of the mp3-files in alphabetical order.
     *
     * @since 1.0
     * @see java.lang.String
     */
    protected String[] arrPlayList;

    /**
     * @param arrFileSongNames Array of File-Objects to generate a playlist for.
     * @since 1.0
     * @see java.io.File
     */
    public M3UPlaylist(java.io.File[] arrFileSongNames) {
        this.arrPlayList = new String[arrFileSongNames.length];
        this.strPlayListName = this.getPlayListName(arrFileSongNames[0]);

        for (int i = 0; i < arrFileSongNames.length; i++) {
            // todo: add usage of ini-settings
            // Filenames without path
            this.arrPlayList[i] = arrFileSongNames[i].getName();
            // Filenames with path
            // this.arrPlayList[i] = arrFileSongNames[i].getParent() + File.separator + arrFileSongNames[i].getName();
        }
        java.util.Arrays.sort(this.arrPlayList);
    }

    /**
     * Create the physical file.
     *
     * @since 1.0
     */
    public void createPlayList() {
        java.io.DataOutputStream objDataOutputStreamPlayList;

        try {
            objDataOutputStreamPlayList = new java.io.DataOutputStream(new java.io.FileOutputStream(this.strPlayListName));
            for (String strSongName : this.arrPlayList) {
                objDataOutputStreamPlayList.writeBytes(strSongName);
                objDataOutputStreamPlayList.writeBytes("\n");
            }
            objDataOutputStreamPlayList.flush();
            objDataOutputStreamPlayList.close();
        } catch (java.io.FileNotFoundException e) {
            System.out.println("FileNotFoundException@createPlayList: " + e);
        } catch (java.io.IOException e) {
            System.out.println("IOException@createPlayList: " + e);
        }
    }

    /**
     * The name of the physical file. Generates with attributes of
     * objFileCurrentDirectory a valid filename with the extension .m3u.
     *
     * @param objFileCurrentDirectory A object of type File containing important
     * informations.
     * @since 1.0
     * @see java.io.File
     */
    private String getPlayListName(java.io.File objFileCurrentDirectory) {
        return objFileCurrentDirectory.getParent() + File.separator + objFileCurrentDirectory.getParent().substring(objFileCurrentDirectory.getParent().lastIndexOf(File.separator) + 1) + ".m3u";
    }
}
