from flask import Flask, render_template, request, redirect, session 
import random
app = Flask(__name__)  
app.secret_key="keep it simple, keep it safe"  
                             

@app.route('/rps')
def rock_paper_scissors():
    if "wins" not in session:
            session["wins"]=0
            session["losses"]=0
            session["ties"]=0
    return render_template('rock_paper.html')    


@app.route('/play', methods=['POST'])
def play():
   comp = random.randint(0,2)
   options = ['rock', 'paper', 'scissors']

   result = {
       "ROCK": {'rock':'ties', 'paper':'losses', 'scissors':'wins'},
       "PAPER": {'rock':'wins','paper':'ties', 'scissors':'losses'},
       "SCISSORS":{'rock':'losses', 'paper':'wins', 'scissors':'ties'}
   }
   session[result[request.form['choice']][options[comp]]]+=1
   return redirect('/rps')

@app.route('/reset')
def reset():
    session.clear()
    return redirect('/rps')

  
                           
app.run(debug=True)    