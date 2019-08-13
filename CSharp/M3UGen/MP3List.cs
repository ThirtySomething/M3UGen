using System;
using System.Collections.Generic;
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
                /// Build list of mp3 files
                /// </summary>
                public class MP3List
                {
                    /// <summary>
                    /// Extension for the playlists
                    /// </summary>
                    private static string strExtensionM3U = ".m3u";

                    /// <summary>
                    /// File extension to find mp3 files
                    /// </summary>
                    private static string strExtensionMP3 = ".mp3";

                    /// <summary>
                    /// Seperator of paths
                    /// </summary>
                    private static char chrPathSeperator = '\\';

                    /// <summary>
                    /// Internal list of album name and FileInfo objects
                    /// </summary>
                    private Dictionary<string, List<FileInfo>> objDictionary = new Dictionary<string, List<FileInfo>>();

                    /// <summary>
                    /// Add an FileInfo object to the internal list
                    /// </summary>
                    /// <param name="objFileInfo">FileInfo</param>
                    /// <returns></returns>
                    public bool mp3SongAdd(FileInfo objFileInfo)
                    {
                        bool bSuccess = false;
                        List<FileInfo> objList = new List<FileInfo>();
                        string strNameAlbum = "";

                        if (0 == String.Compare(MP3List.strExtensionMP3, objFileInfo.Extension, true))
                        {
                            strNameAlbum = this.mp3SongGetNameAlbum(objFileInfo);
                            if (false == this.objDictionary.ContainsKey(strNameAlbum))
                            {
                                this.objDictionary.Add(strNameAlbum, objList);
                            }

                            try
                            {
                                bSuccess = this.objDictionary.TryGetValue(strNameAlbum, out objList);
                                if (true == bSuccess)
                                {
                                    objList.Add(objFileInfo);
                                    bSuccess = true;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: mp3SongAdd [" + e.Message + "]");
                            }
                        }

                        return bSuccess;
                    }

                    /// <summary>
                    /// Extract album name from directory the file resides
                    /// </summary>
                    /// <param name="objFileInfo">FileInfo</param>
                    /// <returns>string</returns>
                    private string mp3SongGetNameAlbum(FileInfo objFileInfo)
                    {
                        string strPathName = objFileInfo.DirectoryName;
                        string[] arrPathParts = strPathName.Split(MP3List.chrPathSeperator);

                        return arrPathParts[arrPathParts.Length - 1];
                    }

                    /// <summary>
                    /// Get filename for playlist
                    /// </summary>
                    /// <param name="objEntry">KeyValuePair<string, List<FileInfo>></param>
                    /// <returns>string</returns>
                    private string getFilenamePlaylist(KeyValuePair<string, List<FileInfo>> objEntry)
                    {
                        return objEntry.Value[0].DirectoryName + Path.DirectorySeparatorChar + objEntry.Key + MP3List.strExtensionM3U;
                    }

                    /// <summary>
                    /// Create playlists for all found mp3
                    /// </summary>
                    /// <returns>integer</returns>
                    public int m3uListGenerate()
                    {
                        int intPlaylists = 0;
                        string strPlaylistName = "";

                        foreach (KeyValuePair<string, List<FileInfo>> objEntry in this.objDictionary)
                        {
                            strPlaylistName = this.getFilenamePlaylist(objEntry);

                            if (System.IO.File.Exists(strPlaylistName))
                            {
                                System.IO.File.Delete(strPlaylistName);
                            }

                            if (0 < objEntry.Value.Count)
                            {
                                intPlaylists++;
                                using (StreamWriter file = new StreamWriter(@strPlaylistName, true))
                                {
                                    foreach (FileInfo objFileInfo in objEntry.Value)
                                    {
                                        if (true == File.Exists(objFileInfo.FullName))
                                        {
                                            file.WriteLine(objFileInfo.Name);
                                        }
                                    }
                                }
                            }
                        }

                        this.objDictionary.Clear();

                        return intPlaylists;
                    }
                }
            }
        }
    }
}
