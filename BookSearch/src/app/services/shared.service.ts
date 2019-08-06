import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  //Deliver data beetween components
  private behavsub = new BehaviorSubject<string>('');
  inputSearchRes = this.behavsub.asObservable();
  constructor() { }
  setInputSearch(txtsearch: string) {
    this.behavsub.next(txtsearch);
  }
}
