import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CreateBook } from './createbook.model';

@Component({
  templateUrl: './createbook.component.html',
})
export class CreateBookComponent implements OnInit {



  ngOnInit(): void {
    this.GetDataFromServer();
  }

  Success(input: any) {
    console.log(input);
    this.CreateBookModels = input;
  }
  constructor(private http: HttpClient) { }

  GetDataFromServer() {
    this.http.get("https://localhost:44323/api/CreateBook").subscribe(res => this.Success(res), res => console.log(res));
  }
  title = 'Digital_Books';
  imageURL = "././assets/image.jpg";
  isEdit = false;

  CreateBookModel: CreateBook = new CreateBook();
  CreateBookModels: Array<CreateBook> = new Array<CreateBook>();
  Add() {
    debugger;

    var createbookdat={
      title : this.CreateBookModel.title,
active : this.CreateBookModel.active,
image : this.CreateBookModel.image,
price : this.CreateBookModel.price,
publisher : this.CreateBookModel.publisher,
content : this.CreateBookModel.content,
category:this.CreateBookModel.category,

    };

    if(this.isEdit){
      this.http.put("https://localhost:44323/api/CreateBook",this.CreateBookModel).subscribe(res=>this.PostSuccess(res),res=>console.log(res))
    }
    else{
      this.http.post("https://localhost:44323/api/CreateBook",createbookdat).subscribe(res=>this.PostSuccess(res),res=>console.log(res))
    }
    this.CreateBookModel = new CreateBook();
  }
  PostSuccess(input: any) {
    this.GetDataFromServer();
  }
  EditBook(input: any) {
    debugger;
    this.isEdit = true;
    this.CreateBookModel = input;
  }
  DeleteBook(input: any) {
    debugger;
    this.http.delete("https://localhost:44323/api/CreateBook?id="+input.id).subscribe(res=>this.PostSuccess(res),res=>console.log(res));
    this.CreateBookModel = input;
  }

}
