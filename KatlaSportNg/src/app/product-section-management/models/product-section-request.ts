export class ProductToSectionRequest {
    constructor(
        public id: number,
        public productId: number,
        public hiveSectionId: number,
        public quantity: number,        
        public status: boolean        
    ) { }
}