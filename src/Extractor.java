import java.io.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

public class Extractor
{
    private static final int  BUFFER_SIZE = 2048;

    public void extract(File zipFile, File destinationPath)
    {

      if(!destinationPath.exists())
      {
          destinationPath.mkdir();
      }

      byte[] buffer = new byte[BUFFER_SIZE];

      try
      {
        FileInputStream fileIn = new FileInputStream(zipFile);
        ZipInputStream zipIn = new ZipInputStream(fileIn);

        ZipEntry entry = zipIn.getNextEntry();

        while(entry != null)
        {

          String entryName = entry.getName();
          File file = new File(destinationPath + File.separator + entryName);

          FileOutputStream fileOut = new FileOutputStream(file);
          int counter = 0;

          while((counter = zipIn.read(buffer)) > 0)
          {
            fileOut.write(buffer, 0, counter);
          }

          fileOut.close();
          zipIn.closeEntry();
	        entry = zipIn.getNextEntry();

        }

          zipIn.close();
          fileIn.close();

      }
      catch(IOException e)
      {
        e.printStackTrace();
      }

    }
}
