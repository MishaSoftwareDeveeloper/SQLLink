import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from "../services/shared.service";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  inputsearch: string;
  userName: string;
  constructor(private route: ActivatedRoute, private shared: SharedService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.userName = params.userName;
    });
  }
  onSearch() {
    //set to BehaviourSubject input search more then 3 letters
    if (this.inputsearch.length >= 3)
      this.shared.setInputSearch(this.inputsearch);
  }

  onSearchChanged() {

    //Clear grid when inputsearch cleared
    if (this.inputsearch.length == 0)
      this.shared.setInputSearch(this.inputsearch);
  }



}
