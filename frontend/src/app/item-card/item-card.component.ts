import {Component, Input, OnInit} from '@angular/core';
import {Item} from "../adminpage/adminitem/ItemDto";
import {Category} from "../adminpage/admincatgory/CategoryDto";
import {Option} from "../adminpage/andminoption/OptionDto";

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {
  @Input() item: Item;
  @Input() categories : Category[];
  @Input() options: Option[];

  constructor() {
    this.item = {
      id: 0,
      name: '',
      price: 0,
      optionIds: [],
      itemCategoryId: 0,
    };
    this.options = [];
    this.categories = [];
  }

  ngOnInit(): void {
  }

  getCategory(categoryId: number) : Category {
    return this.categories.find((c : Category) => c.id == categoryId) || {id: 0, categoryName: ''};
  }

  getOption(optionId: number) : Option {
    return this.options.find((o : Option) => o.id == optionId) || {id: 0, name: '', optionGroupId: 0};
  }

}
