using System;
using System.IO;

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                /// <summary>
                /// Generates m3u playlists for all mp3 files found
                /// </summary>
                public class M3UGen
                {
                    /// <summary>
                    /// Path to start the search for the mp3 files
                    /// </summary>
                    private string strMP3BaseDir = "";

                    /// <summary>
                    /// Set the base directory
                    /// </summary>
                    /// <param name="strDirectory">string</param>
                    /// <returns>bool</returns>
                    private bool mp3BaseDirSet(string strDirectory)
                    {
                        bool bIsValidBaseDir = Directory.Exists(strDirectory);

                        this.strMP3BaseDir = "";
                        if (true == bIsValidBaseDir)
                        {
                            this.strMP3BaseDir = strDirectory;
                        }
                        else
                        {
                            throw new Exception("Directory [" + strDirectory + "] does not exist.");
                        }

                        return bIsValidBaseDir;
                    }

                    /// <summary>
                    /// Recursive search for mp3 files in all (sub-)directories
                    /// </summary>
                    /// <param name="objStartDir">DirectoryInfo</param>
                    /// <param name="objMP3List">MP3List</param>
                    /// <returns></returns>
                    private void handleDirectory(DirectoryInfo objStartDir, MP3List objMP3List)
                    {
                        FileInfo[] arrFiles = null;
                        DirectoryInfo[] arrSubDirs = null;

                        try
                        {
                            arrFiles = objStartDir.GetFiles();
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Console.WriteLine("UnauthorizedAccessException in M3UGen::handleDirectory [" + e.Message + "]");
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            Console.WriteLine("DirectoryNotFoundException in M3UGen::handleDirectory [" + e.Message + "]");
                        }

                        if (null != arrFiles)
                        {
                            foreach (FileInfo objFileInfo in arrFiles)
                            {
                                objMP3List.mp3SongAdd(objFileInfo);
                            }
                        }

                        arrSubDirs = objStartDir.GetDirectories();
                        foreach (DirectoryInfo objDirectoryInfo in arrSubDirs)
                        {
                            this.handleDirectory(objDirectoryInfo, objMP3List);
                        }
                    }

                    /// <summary>
                    /// Start population of mp3 list
                    /// </summary>
                    /// <param name="objMP3List">MP3List</param>
                    /// <returns></returns>
                    private void mp3PopulateList(MP3List objMP3List)
                    {
                        DirectoryInfo objStartDir = new DirectoryInfo(this.strMP3BaseDir);
                        this.handleDirectory(objStartDir, objMP3List);
                    }

                    /// <summary>
                    /// Set start directory and generate all playlists
                    /// </summary>
                    /// <param name="strDirectoryStart">string</param>
                    /// <param name="objMP3List">MP3List</param>
                    /// <returns>string</returns>
                    public string generatePlaylists(string strDirectoryStart, MP3List objMP3List)
                    {
                        string strReturnMessage = "";
                        int intPlaylistsGenerated = 0;

                        try
                        {
                            this.mp3BaseDirSet(strDirectoryStart);
                            this.mp3PopulateList(objMP3List);
                            intPlaylistsGenerated = objMP3List.m3uListGenerate();
                            strReturnMessage = "Generated " + intPlaylistsGenerated + " playlist(s)";
                        }
                        catch (Exception e)
                        {
                            strReturnMessage = e.Message;
                        }

                        return strReturnMessage;
                    }
                }
            }
        }
    }
}
