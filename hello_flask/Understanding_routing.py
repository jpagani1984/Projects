from flask import Flask   
app = Flask(__name__)     
                          
print(__name__)           
@app.route('/dojo')           
                          
                          
def Dojo():
    return 'Dojo'
     

@app.route('/say/flask')           
                          
                          
def hi_flask():
    return 'Hi Flask'
      

@app.route('/say/micheal')           
                          
                          
def say_micheal():
    return 'HI MICHEAL'  
   

@app.route('/say/john')           
                          
                          
def say_john():
    return 'HI JOHN'  
   

@app.route('/repeat/35/hello')           
                          
                          
def say_hello():

    return 'hello' *int(35)
 

@app.route('/repeat/99/dogs')           
                          
                          
def repeat_dogs():
    return 'DOGS!!' *int(99) 
       

if __name__=="__main__":  
                            
    app.run(debug=True) 