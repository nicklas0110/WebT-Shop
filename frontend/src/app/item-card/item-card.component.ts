import {Component, EventEmitter, Input, OnInit} from '@angular/core';
import {Item} from "../adminpage/adminitem/ItemDto";
import {Category} from "../adminpage/admincatgory/CategoryDto";
import {Option} from "../adminpage/andminoption/OptionDto";
import { HttpService } from 'src/services/http.service';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { Token } from 'src/services/authguard.service';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {
  @Input() item: Item;
  @Input() categories : Category[];
  @Input() options: Option[];

  user: Token | undefined;

  constructor(private http: HttpService, private router: Router) {
    this.item = {
      id: 0,
      name: '',
      image: '',
      price: 0,
      optionIds: [],
      itemCategoryId: 0,
    };
    this.options = [];
    this.categories = [];
  }

  ngOnInit(): void {
    // Load user info from jwt when page is changed
    this.router.events.subscribe(() => {
      this.loadUserFromJwt();
    });

    // Load Initial
    this.loadUserFromJwt();
  }

  loadUserFromJwt() {
    const token = localStorage.getItem('token');
    console.log(token);
    this.user = token ? jwtDecode(token!) as Token : undefined;
  }

  getCategory(categoryId: number) : Category {
    return this.categories.find((c : Category) => c.id == categoryId) || {id: 0, categoryName: ''};
  }

  getOption(optionId: number) : Option {
    return this.options.find((o : Option) => o.id == optionId) || {id: 0, name: '', optionGroupId: 0};
  }

  buy(item: Item) {
    this.http.removeBalance(this.user?.id!, { balance: item.price });
  }
}
