from flask import Flask, render_template
app = Flask(__name__)    
                             

@app.route('/test')


def hello_world():
  return render_template('hello_world.html', name = "Joe")

if __name__=="__main__":   
                           
    app.run(debug=True)    
