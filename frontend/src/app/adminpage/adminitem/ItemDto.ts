
export class ItemDto {
    name: string = "";
    price: number = 0;
    itemCategoryId: number = 0;
    optionIds: number[] = [];
}
// Sets the id when it is needed
export class Item extends ItemDto{
    id: number = 0;
}