# Inventory API Documentation
*This documentation provides an overview of how this API works*

## Base Url

The base url for this API is: [BASEURL](www.facebook.com)


## End Points


### Products Endpoint

#### - Add Products 
- **URL**: `api/Product`
- **Method**: POST
- **Description**: Add a new product
- **Request Body**: 
```json
{
  "name": "Mouse",
  "inStock": false,
  "quantity": 0
}
```
- **Format**: application/json 
- **Example Request**	
 POST `https://localhost.com/api/Product` 
```json
{
  "name": "Mouse",
  "inStock": false,
  "quantity": 0
}
```

- **Example successful response**
```json
{
  "isSuccessful": true,
  "message": "Product Successfully added",
  "result": {
    "id": 8,
    "name": "Laptop",
    "inStock": true,
    "quantity": 20
  },
  "resultCode": 200
}
```

- **Example failed response**
```json
{
  "isSuccessful": false,
  "message": "Operation Unsuccessful",
  "result": null,
  "resultCode": 400
}

```

#### - Get Product 
- **URL**: `api/Product/{id}`
- **Method**: GET
- **Description**: Get a product by it's Id
- **Parameter**:
    - `Id` (int)   
- **Example Request**	
 GET `https://localhost.com/api/Product/{id}` 

- **Example successful response**
```json
{
  "isSuccessful": true,
  "message": "Operation Successful",
  "result": {
    "id": 2,
    "name": "Elders Schnapps",
    "inStock": true,
    "quantity": 17
  },
  "resultCode": 200
}
```

- **Example failed response**
```json
{
  "isSuccessful": false,
  "message": "Product does not exist",
  "result": null,
  "resultCode": 404
}

```

#### - Get All Products 
- **URL**: `api/Product/Products`
- **Method**: GET
- **Description**: Get all products  
- **Example Request**	
 GET `https://localhost.com/api/Product/Products` 

- **Example successful response**
```json
{
     [
      {
        "id": 1,
        "name": "Hp EliteBook 745 G6",
        "inStock": true,
        "quantity": 17
      },
      {
        "id": 2,
        "name": "Elders Schnapps",
        "inStock": true,
        "quantity": 17
      },
      {
        "id": 3,
        "name": "Mac Book Pro 2024",
        "inStock": true,
        "quantity": 6
      },
      {
        "id": 4,
        "name": "Iphone 16pro max",
        "inStock": true,
        "quantity": 4
      },
      {
        "id": 5,
        "name": "Bottled Groudnut",
        "inStock": true,
        "quantity": 18
      },
      {
        "id": 6,
        "name": "CWAY",
        "inStock": true,
        "quantity": 18
      },
      {
        "id": 7,
        "name": "Beans",
        "inStock": true,
        "quantity": 40
      },
      {
        "id": 8,
        "name": "Laptop",
        "inStock": true,
        "quantity": 20
      },
      {
        "id": 9,
        "name": "Mouse",
        "inStock": false,
        "quantity": 0
      },
      {
        "id": 10,
        "name": "Mouse",
        "inStock": false,
        "quantity": 0
      }
    ]
}
```

- **Example failed response**
```json
{
 
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "Not Found",
  "status": 404,
  "traceId": "00-d3c54f6a5588757b612fa2f783a607c4-b645b03f88548bae-00"

}

```

#### - Update Product 
- **URL**: `api/Product/{id}`
- **Method**: PUT
- **Description**: Update a product
- **Parameter**:
    - `Id` (int)   
- **Request Body**: 
```json
{
  "name": "Mouse",
  "inStock": false,
  "quantity": 0
}
```
- **Format**: application/json
- **Example Request**	
 PUT `https://localhost.com/api/Product/{id}` 

- **Example successful response**
```json
{
  "isSuccessful": true,
  "message": "Operation Successful",
  "result": {
    "id": 2,
    "name": "Elders Schnapps",
    "inStock": true,
    "quantity": 17
  },
  "resultCode": 200
}
```

- **Example failed response**
```json
{
  "isSuccessful": false,
  "message": "Operation unsuccessful",
  "result": null,
  "resultCode": 404
}

```

#### - Update Products 
- **URL**: `api/Product/Products`
- **Method**: PUT
- **Description**: Update products with quantity greater than 0 but have an instock value of false 
- **Example Request**	
 PUT `https://localhost.com/api/Product/Products` 

- **Example successful response**
```json
{
  "isSuccessful": false,
  "message": "All matching products successfully updated",
  "result": [],
  "resultCode": 200
}
```

- **Example failed response**
```json
{
  "isSuccessful": false,
  "message": "No products matches....",
  "result": null,
  "resultCode": 400
}
```

#### - Delete Product 
- **URL**: `api/Product/{id}`
- **Method**: DELETE
- **Description**: Delete a product
- **Parameter**:
    - `Id` (int)   
- **Example Request**	
 DELETE `https://localhost.com/api/Product/{id}` 

- **Example successful response**
```json
{
  "isSuccessful": true,
  "message": "Product Successfully Deleted",
  "result": null,
  "resultCode": 200
}
```

- **Example failed response**
```json
{
  "isSuccessful": false,
  "message": "Product does not exist",
  "result": null,
  "resultCode": 404
}

```