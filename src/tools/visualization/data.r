# Accepts a list of arguements and that takes a csv file and truncates it to a set size.
# currently only set to ~/Senior Capstone Project/res/MNIST data
setwd("~/Senior Capstone Project/res/MNIST data/")
options(echo = FALSE)
args <- commandArgs(TRUE)

infile <- args[1]
trunc <- args[2]
outfile <- args[3]


if (length(args)==0) {
  stop("At least one argument must be supplied (input file).n", call.=FALSE)
}


if ("--help" %in% args) {
  cat("
      Usage:
      
      RScript --vanilla [in] | [trunc] | [out]
      
      in - the file that were truncating
      trunc - the ammount were trunacting to
      out - the file that is saved.


      ")
}

rm(args)

#input the CSV files
train <- read.csv(file = "train.csv", header = TRUE)



# get 300 values from the train data set.

ShortDataSet <- train[ 301 :as.numeric(600),]

write.csv(ShortDataSet, file =  "train2.csv") 


mytst <- read.csv(file = "test.csv", header = TRUE)
train <- read.csv(file = "train.csv", header =TRUE)


mytst$X <- NULL
mytst$label <- NULL

write.csv(mytst, file =  "test.csv") 








