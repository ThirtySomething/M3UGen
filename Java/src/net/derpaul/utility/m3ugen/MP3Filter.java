package net.derpaul.utility.m3ugen;

/**
 * @author Jochen Paul
 * @version 1.0
 * @see BaseFilter
 */
public class MP3Filter extends BaseFilter {

    /**
     * @param strFileMask Set the compare-strMask with creation of the object.
     * @since 1.0
     * @see java.lang.String
     */
    public MP3Filter(String strFileMask) {
        this.strMask = strFileMask.toUpperCase();
    }
}
