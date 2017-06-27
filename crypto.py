#Program to create a cipher string to be used
# as Demo to C# program

import base64
from Crypto.Cipher import PKCS1_v1_5
from Crypto.PublicKey import RSA


key = RSA.importKey(open('./example_rsa.pem.pub'))
cipher = PKCS1_v1_5.new(key)
print(base64.b64encode(cipher.encrypt('Hello World. This is a test.')))
