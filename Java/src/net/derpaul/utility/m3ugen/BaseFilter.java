package net.derpaul.utility.m3ugen;

/**
 * @author Jochen Paul
 * @version 1.0
 * @see java.lang.Object
 * @see java.io.FilenameFilter
 */
public abstract class BaseFilter extends Object implements java.io.FilenameFilter {

    /**
     * The strMask where to compare to.
     *
     * @since 1.0
     */
    protected String strMask = null;

    /**
     * @param objFileDirectory Directory to filter 
     * @param strName File extension to check for
     * @since 1.0
     * @see java.io.File
     * @see java.io.FilenameFilter
     * @see java.lang.String
     */
    @Override
    public boolean accept(java.io.File objFileDirectory, String strName) {
        return strName.toUpperCase().endsWith(this.strMask);
    }
}
