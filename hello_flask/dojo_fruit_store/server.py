from flask import Flask, render_template, request, session, redirect
from datetime import datetime
app = Flask(__name__)
app.secret_key="May the fourth be with you"

@app.route('/store')         
def index():
    session.clear()
    return render_template("index.html")

@app.route('/checkout', methods=['POST'])         
def checkout():
    session['first_name'] = request.form['first_name']
    session['last_name'] = request.form['last_name']
    session['student_id'] = request.form['student_id']
    session['strawberry'] = request.form['strawberry']
    session['blackberry'] = request.form['blackberry']
    session['raspberry'] = request.form['raspberry']
    session['apple'] = request.form['apple']
    session['datetime'] = datetime.now()
    count = int(session['strawberry'])+int(session['raspberry'])+int(session['blackberry'])+int(session['apple'])
    print(request.form)
    return render_template("checkout.html", count = count)

@app.route('/fruits')         
def fruits():
    return render_template("fruits.html")

if __name__=="__main__":   
    app.run(debug=True)    