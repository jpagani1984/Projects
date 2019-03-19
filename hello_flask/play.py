from flask import Flask, render_template
app = Flask(__name__)    
                             

@app.route('/play/<multi>/<color>')


def hello_world(multi,color):
    return render_template('play.html', bananarama = int(multi), color = color)



if __name__=="__main__":   
                           
    app.run(debug=True)    