using System;
using System.Collections.Generic;

public class DocumentSystem
{
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static List<Document> allDocuments = new List<Document>();
 
    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }
  
    private static void AddTextDocument(string[] attributes)
    {
        TextDocument doc = new TextDocument();
        foreach (var attribute in attributes)
        {
            string[] atrAndValue = attribute.Split('=');
            string atr = atrAndValue[0];
            string value = atrAndValue[1];
            doc.LoadProperty(atr,value);
        }
        if (doc.Name != null)
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddPdfDocument(string[] attributes)
    {
        PDFDocument doc = new PDFDocument();
        foreach (var attribute in attributes)
        {
            string[] atrAndValue = attribute.Split('=');
            string atr = atrAndValue[0];
            string value = atrAndValue[1];
            doc.LoadProperty(atr, value);
        }
        if (doc.Name != null)
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddWordDocument(string[] attributes)
    {
        WordDocument doc = new WordDocument();
        foreach (var attribute in attributes)
        {
            string[] atrAndValue = attribute.Split('=');
            string atr = atrAndValue[0];
            string value = atrAndValue[1];
            doc.LoadProperty(atr, value);
        }
        if (doc.Name != null)
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddExcelDocument(string[] attributes)
    {
        ExcelDocument doc = new ExcelDocument();
        foreach (var attribute in attributes)
        {
            string[] atrAndValue = attribute.Split('=');
            string atr = atrAndValue[0];
            string value = atrAndValue[1];
            doc.LoadProperty(atr, value);
        }
        if (doc.Name != null)
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AudioDocument doc = new AudioDocument();
        foreach (var attribute in attributes)
        {
            string[] atrAndValue = attribute.Split('=');
            string atr = atrAndValue[0];
            string value = atrAndValue[1];
            doc.LoadProperty(atr, value);
        }
        if (doc.Name != null)
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddVideoDocument(string[] attributes)
    {
        VideoDocument doc = new VideoDocument();
        foreach (var attribute in attributes)
        {
            string[] atrAndValue = attribute.Split('=');
            string atr = atrAndValue[0];
            string value = atrAndValue[1];
            doc.LoadProperty(atr, value);
        }
        if (doc.Name != null)
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void ListDocuments()
    {
        if (allDocuments.Count > 0)
        {
            foreach (var  document in  allDocuments)
            {
                Console.WriteLine(document);
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        bool foundDocName = false;
        foreach (var document in allDocuments)
        {
            if (document.Name == name)
            {
                foundDocName = true;
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", name);
                    break;
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", name);
                    break;
                }
            }
        }
        if (!foundDocName)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool foundDocName = false;
        foreach (var document in allDocuments)
        {
            if (document.Name == name)
            {
                foundDocName = true;
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", name);
                    break;
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", name);
                    break;
                }
            }
        }
        if (!foundDocName)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool encryptedDocsFound = false;
        foreach (var document in allDocuments)
        {
            if (document is IEncryptable)
            {
                encryptedDocsFound = true;
                ((IEncryptable)document).Encrypt();
            }
        }
        if (encryptedDocsFound)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool isDocFound = false;
        foreach (var document in allDocuments)
        {
            if (document.Name == name)
            {
                isDocFound = true;
                if (document is IEditable)
                {
                    ((IEditable)document).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", name);
                    break;
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", name);
                }
            }
        }
        if (!isDocFound)
        {
            Console.WriteLine("Document not found: {0}",name);
        }
    }
}