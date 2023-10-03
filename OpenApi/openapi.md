### 概要
Update an existing pet
### put /pet
### 説明
Update an existing pet by Id
### requestBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/Pet"
  }
}
```

### responseBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/Pet"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | Successful operation |
| **400** | Invalid ID supplied |
| **404** | Pet not found |
| **405** | Validation exception |

---

### 概要
Add a new pet to the store
### post /pet
### 説明
Add a new pet to the store
### requestBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/Pet"
  }
}
```

### responseBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/Pet"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | Successful operation |
| **405** | Invalid input |

---

### 概要
Finds Pets by status
### get /pet/findByStatus
### 説明
Multiple status values can be provided with comma separated strings
### requestBody
```json title="Exsample"

```

### responseBody
```json title="Exsample"
{
  "schema": {
    "type": "array",
    "items": {
      "$ref": "#/components/schemas/Pet"
    }
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |
| **400** | Invalid status value |

---

### 概要
Finds Pets by tags
### get /pet/findByTags
### 説明
Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
### requestBody
```json title="Exsample"

```

### responseBody
```json title="Exsample"
{
  "schema": {
    "type": "array",
    "items": {
      "$ref": "#/components/schemas/Pet"
    }
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |
| **400** | Invalid tag value |

---

### 概要
Find pet by ID
### get /pet/{petId}
### 説明
Returns a single pet
### requestBody
```json title="Exsample"

```

### responseBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/Pet"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |
| **400** | Invalid ID supplied |
| **404** | Pet not found |

---

### 概要
Updates a pet in the store with form data
### post /pet/{petId}
### 説明

### requestBody
```json title="Exsample"

```

| コード  | 説明  |
| ------ | ---- |
| **405** | Invalid input |

---

### 概要
Deletes a pet
### delete /pet/{petId}
### 説明
delete a pet
### requestBody
```json title="Exsample"

```

| コード  | 説明  |
| ------ | ---- |
| **400** | Invalid pet value |

---

### 概要
uploads an image
### post /pet/{petId}/uploadImage
### 説明

### requestBody
```json title="Exsample"

```

### responseBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/ApiResponse"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |

---

### 概要
Returns pet inventories by status
### get /store/inventory
### 説明
Returns a map of status codes to quantities
### requestBody
```json title="Exsample"

```

### responseBody
```json title="Exsample"
{
  "schema": {
    "type": "object",
    "additionalProperties": {
      "type": "integer",
      "format": "int32"
    }
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |

---

### 概要
Place an order for a pet
### post /store/order
### 説明
Place a new order in the store
### requestBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/Order"
  }
}
```

### responseBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/Order"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |
| **405** | Invalid input |

---

### 概要
Find purchase order by ID
### get /store/order/{orderId}
### 説明
For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions.
### requestBody
```json title="Exsample"

```

### responseBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/Order"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |
| **400** | Invalid ID supplied |
| **404** | Order not found |

---

### 概要
Delete purchase order by ID
### delete /store/order/{orderId}
### 説明
For valid response try integer IDs with value < 1000. Anything above 1000 or nonintegers will generate API errors
### requestBody
```json title="Exsample"

```

| コード  | 説明  |
| ------ | ---- |
| **400** | Invalid ID supplied |
| **404** | Order not found |

---

### 概要
Create user
### post /user
### 説明
This can only be done by the logged in user.
### requestBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/User"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **default** | successful operation |

---

### 概要
Creates list of users with given input array
### post /user/createWithList
### 説明
Creates list of users with given input array
### requestBody
```json title="Exsample"
{
  "schema": {
    "type": "array",
    "items": {
      "$ref": "#/components/schemas/User"
    }
  }
}
```

### responseBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/User"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | Successful operation |
| **default** | successful operation |

---

### 概要
Logs user into the system
### get /user/login
### 説明

### requestBody
```json title="Exsample"

```

### responseBody
```json title="Exsample"
{
  "schema": {
    "type": "string"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |
| **400** | Invalid username/password supplied |

---

### 概要
Logs out current logged in user session
### get /user/logout
### 説明

### requestBody
```json title="Exsample"

```

| コード  | 説明  |
| ------ | ---- |
| **default** | successful operation |

---

### 概要
Get user by user name
### get /user/{username}
### 説明

### requestBody
```json title="Exsample"

```

### responseBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/User"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **200** | successful operation |
| **400** | Invalid username supplied |
| **404** | User not found |

---

### 概要
Update user
### put /user/{username}
### 説明
This can only be done by the logged in user.
### requestBody
```json title="Exsample"
{
  "schema": {
    "$ref": "#/components/schemas/User"
  }
}
```

| コード  | 説明  |
| ------ | ---- |
| **default** | successful operation |

---

### 概要
Delete user
### delete /user/{username}
### 説明
This can only be done by the logged in user.
### requestBody
```json title="Exsample"

```

| コード  | 説明  |
| ------ | ---- |
| **400** | Invalid username supplied |
| **404** | User not found |

---

--Schema---
□ Order
|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |
| id         | int64      |   -   |   -   |                      |
| petId      | int64      |   -   |   -   |                      |
| quantity   | int32      |   -   |   -   |                      |
| shipDate   | date-time  |   -   |   -   |                      |
| status     |            |   -   |   -   | Order Status         |
| complete   |            |   -   |   -   |                      |
□ Customer
|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |
| id         | int64      |   -   |   -   |                      |
| username   |            |   -   |   -   |                      |
| address    |            |   -   |   -   |                      |
□ Address
|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |
| street     |            |   -   |   -   |                      |
| city       |            |   -   |   -   |                      |
| state      |            |   -   |   -   |                      |
| zip        |            |   -   |   -   |                      |
□ Category
|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |
| id         | int64      |   -   |   -   |                      |
| name       |            |   -   |   -   |                      |
□ User
|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |
| id         | int64      |   -   |   -   |                      |
| username   |            |   -   |   -   |                      |
| firstName  |            |   -   |   -   |                      |
| lastName   |            |   -   |   -   |                      |
| email      |            |   -   |   -   |                      |
| password   |            |   -   |   -   |                      |
| phone      |            |   -   |   -   |                      |
| userStatus | int32      |   -   |   -   | User Status          |
□ Tag
|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |
| id         | int64      |   -   |   -   |                      |
| name       |            |   -   |   -   |                      |
□ Pet
|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |
| id         | int64      |   -   |   -   |                      |
| name       |            |   -   |   -   |                      |
| category   |            |   -   |   -   |                      |
| photoUrls  |            |   -   |   -   |                      |
| tags       |            |   -   |   -   |                      |
| status     |            |   -   |   -   | pet status in the store |
□ ApiResponse
|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |
| code       | int32      |   -   |   -   |                      |
| type       |            |   -   |   -   |                      |
| message    |            |   -   |   -   |                      |

