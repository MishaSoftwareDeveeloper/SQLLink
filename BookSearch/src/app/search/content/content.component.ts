import { Component, OnInit } from '@angular/core';
import { BackendService } from "../../services/backend.service";
import { SharedService } from "../../services/shared.service";

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {
  books: any[];
  inputsearch: string;
  selectedBook: any;
  displayDialog: boolean;
  constructor(private api: BackendService,
    private shared: SharedService,) { }

  ngOnInit() {
    //Get last search input from BehaviourSubject and fill grid
    this.shared.inputSearchRes.subscribe(txt => {
      if (txt.length >= 3) {
        this.fillContent(txt);
        this.inputsearch = txt;
      }
      else
        this.books = [];
    })
  }

  fillContent(inputsearch) {
    //fill grid by search input

    this.api.getBooks(inputsearch).subscribe((res: any) => {
      debugger;
      this.books = res.items;
    },
      err => { console.log('Error: ' + err); })
  }


  onSelectBook(event, book) {
    this.selectedBook = book;
    this.displayDialog = true;
    event.preventDefault();
  }
  onDialogHide() {
    this.selectedBook = null;
  }

}
