boiler_plate = """ """
file_string = ""
properties  = []


def GetClassName()
  print "Enter a class name: "
  return STDIN.gets.chomp
end

def BuildConstructor(class_name)
  return """
    public #{class_name}(){

    }
  """
end

def CreateProperty(property_name, property_type)
  prop_data = {}
  prop_data[:field] = "    public #{property_type} #{property_name};\n"
  prop_data[:setter] = """
    public #{property_type} set#{property_name}(int newValue){
        #{property_name} = newValue;
    }
  """
  prop_data[:getter] = """
    public void get#{property_name}(){
      return #{property_name};
    }
  """
  return prop_data
end

#Get the class name
class_name = GetClassName()

# Get the raw property_data
while true
  puts "Type END in the name field when you are done"

  print "Enter the name of the property: "
  name = STDIN.gets.chomp

  if name.chomp == "END"
    break
  end

  print "Enter the type of the property (Please enter a valid type, i.e int not Integer): "
  type = STDIN.gets.chomp

  properties << CreateProperty(name, type)
end

fields = []
getters = []
setters = []

properties.each do |prop|
  fields << prop[:field]
  getters << prop[:getter]
  setters << prop[:setter]
end

#Get the name of the class and create the constructor
constructor_string = BuildConstructor(class_name)

class_string = """public class #{class_name} {\n\n"""

# Add the property fields to the top
fields.each do |field_string|
  class_string += field_string
end

# Append constructor to the class string
class_string += constructor_string

#add the getter and setters
getters.length.times do |i|
  class_string += getters[i]
  class_string += setters[i]
end

class_string += "}"

File.write("#{class_name}.java", class_string)
