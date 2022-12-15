
export class OptionDto {
    name: string = "";
    optionGroupId: number = 1;
}
// Sets the id when it is needed
export class Option extends OptionDto{
    id: number = 0;
}
