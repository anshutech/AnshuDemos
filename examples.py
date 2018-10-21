#EXAMPLES
#VARIABLES
x="anshu"
z=1
#NUMBERS
x=1
y=1.0
w=1j
#Get the character at position 1 (remember that the first character has the position 0):
k = "ANSHU"
print(k[1])
#TUPLE
mytuple=("anshu","tanya","kritika")
print(mytuple)
#dictionary

thisdict = {
           "name": "anshu",
           "friend": "khushi"
}
print(thisdict)



#IF ELSE
U = 33
G = 200
if G > U:
  print("G is greater than U")


#WHILE LOOP
i = 1
while i < 11:
  print(i)
  i += 1



  #FOR LOOP
CARS = ["VOLVO", "SWIFT", "BMW"]
for x in CARS:
  print(x)


  #ARRAYS
GIRLS= ["ANSHU", "TANYA", "KRITIKA"]
print(GIRLS)


  #iterators
mytuple = ("apple", "banana", "cherry")
myit = iter(mytuple)
print(next(myit))
print(next(myit))
print(next(myit))


#dates
import datetime
x = datetime.datetime.now()
print(x)


f = open("demofile.txt", "r")
print(f.read())
