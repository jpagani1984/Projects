from flask import Flask, render_template, redirect
app = Flask(__name__)    
                             

@app.route('/animal/<multi>')


def cute_animals(multi):
    return render_template('cute_animals.html', x = int(multi))

@app.route('/animal/danger')


def danger():
    
    return redirect('/animal')
                           
app.run(debug=True)    