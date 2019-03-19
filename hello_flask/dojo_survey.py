from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)  
app.secret_key="May the fourth be with you"  
                             

@app.route('/survey')
def survey():
    session.clear()
    return render_template('dojo_survey.html')    


@app.route('/submit', methods=['POST'])
def submit(): 
    session['name'] = request.form["NAME"]
    session['location'] = request.form["Dojo Location"]
    session['language'] = request.form["Favorite Language"]
    session['comment'] = request.form["comment"]
    
    return redirect('/result')
    
       

@app.route('/result')
def danger():
    
    return render_template('survey_results.html')

  
                           
app.run(debug=True)    