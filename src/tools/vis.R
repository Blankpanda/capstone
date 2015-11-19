setwd("~/Senior Capstone Project/res/MNIST data/")


#input the CSV files

# test <- read.csv("test.csv" , header = TRUE) our project will only use one data set.
train <- read.csv("train.csv", header = TRUE )


nrow(train)
ncol(train)

# get 300 values from the train data set.
ShortDataSet <- train[ 1 :300,]


par(bg="white")


for (i in 1:10) {
  jpeg(paste("m", as.character(i), ".jpg",  sep = ""))  
  m = matrix(unlist(ShortDataSet[i,-1]), nrow = 28, byrow = T)
  image(m, col = c("Grey100", "Grey0"))
  
    
}

dev.off()
