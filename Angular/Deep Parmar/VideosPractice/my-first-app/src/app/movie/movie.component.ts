import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})

// class Movie 
// {  
//   title : string;  
//   director : string;  
//   cast : string;  
//   releaseDate : string; 
  
//   constructor(title : string,
//     director : string , 
//     cast : string, 
//     releaseDate : string)
//   {
//     this.title = title;  
//     this.director = director;  
//     this.cast = cast;  
//     this.releaseDate = releaseDate; 
//   }
// } 


export class MovieComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

    movies:any[] =[  
    {title:'Zootopia',director:'Byron Howard, Rich Moore',cast:'Idris Elba, Ginnifer Goodwin, Jason Bateman',releaseDate:'March 4, 2016'},  
    {title:'Batman v Superman: Dawn of Justice',director:'Zack Snyder',cast:'Ben Affleck, Henry Cavill, Amy Adams',releaseDate:'March 25, 2016'},  
    {title:'Captain America: Civil War',director:'Anthony Russo, Joe Russo',cast:'Scarlett Johansson, Elizabeth Olsen, Chris Evans',releaseDate:'May 6, 2016'},  
    {title:'X-Men: Apocalypse',director:'Bryan Singer',cast:'Jennifer Lawrence, Olivia Munn, Oscar Isaac',releaseDate:'May 27, 2016'},  
  ] 
}
 