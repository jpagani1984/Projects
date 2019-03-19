from flask import Flask, render_template
app = Flask(__name__)    
                             

@app.route('/checkers/<multi>/<color1>/<color2>')


def checker_board(multi,color1,color2):
    return render_template('checker_board.html', bananarama = int(multi), color1 = color1 , color2 =  color2)



if __name__=="__main__":   
                           
    app.run(debug=True)    