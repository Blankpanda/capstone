# create some visuals of the graphs/numbers
# takes a csv as an input
# currently set to ~/Senior Capstone Project/res/MNIST data/

setwd("~/Senior Capstone Project/res/MNIST data/")

options(echo = FALSE)
args <- commandArgs(TRUE)

ShortDataSet <- read.csv("train.csv", header = TRUE)
count <- 300


if (length(args) < 2) {
  stop("At least two argument must be supplied invoke the script with --help", call.=FALSE)
}


if ("--help" %in% args) {
  cat("
      Usage:
      
      RScript --vanilla [in]
      in - the file that were graphing.
      count - the number of images were grapphing.
      
      ")
}


rot <- function(x) t(apply(x,2,rev))


par(bg="white")

for (i in 1:as.numeric(count)) {
  jpeg(paste("m", as.character(i), ".jpg",  sep = ""))  
  m = rot(matrix(unlist(ShortDataSet[i,-1]), nrow = 28, byrow = T))
  image(m, col = c("Grey100", "Grey0"))
  
  dev.off()
    
}

