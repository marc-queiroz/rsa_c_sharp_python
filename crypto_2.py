import base64

from cryptography.hazmat.primitives import hashes
from cryptography.hazmat.primitives.asymmetric import padding, utils
from cryptography.hazmat.primitives.serialization import load_pem_public_key
from cryptography.hazmat.backends import default_backend

key = load_pem_public_key(open('./example_rsa.pem.pub').read().encode(), backend=default_backend())
cipher = base64.b64encode(key.encrypt('Hello World. This is a test using Python3'.encode(), padding.PKCS1v15()))
print(cipher)
