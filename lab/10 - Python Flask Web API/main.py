from flask import Flask
import string

app = Flask(__name__)

@app.route('/', methods=['GET'])
def get_data():
    message = "🔥 This is fine"
    print(message)
    return message

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=80)
