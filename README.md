# Objective

Transform an RSA encrypted message from python Crypto library to be decrypted in a C# program.

## Python - cypher generator

The python program is very simple, take a string example an generate a a HASH (cipher message) using the public key generated from example_rsa (key).

## C# - Encoder and Decoder

To test the python program both encrypt and decrypt part was implemented. Using a XML representation of the PEM public and private part, generated from the keys from files example_rsa.pem and example_rsa.pem.pub, one can cipher and decipher a message. "Hello World!" is used as a demo of the program. Using the program with a parameter like:

*$mono test.exe 'bFdbpCEElXhWj3TDdxsz9fTP0+I7MvBgIaH45+a89vKkgmVPbTqaVnUTmFkmvtp3d/g6KTWu7J5YAaek4Xxphc0F7G0lC9NmFuYCzKz6hpBFn3cXWqm16UIwG56+Y63IQJ4ypbWr/dhnIWeKNnwObV1g9mf8fDoJ7/QLEMew/llrvkUvpQIu3xJfK+ywWctMgch6XGN1WctnlYCXi4Gj7HJQThshD1tEMx86n/ts9J1jZMhB8XzVIke++WuHbNX6fQkpPH2e/mUyRbmaU91zXYQnk5jc6lOfKm3JPNt2NeCloT7IEgkctw232kea9wA1ukou2GeILSry33EnwfhDFg=='*

You can see a decrypted message. This cipher message was generated from the python program included.

This is the expected output:

`Hello World. This is a test.`

Remember there is a test already in place for the code, 'Hello World!'.

## Information how to run an compile the code.

For the *python* program you should have installed the libraries in the header. As pieces of codes I made use of ipython (REPL console) to run the codes.

As a linux (Arch) user, I had to install mono to be able to construct the code in test.cs, using the instructions inside the file.

To convert PEM to XML used by RSA implementation of C# libraries one can use a site to translate it, [https://superdry.apphb.com/tools/online-rsa-key-converter]. I used a personal code to create this translations, be aware to use external tools to avoid security breachs.

### Happy RSA encryption!
