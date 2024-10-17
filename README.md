- 介面
![1](images/interface.png)

- 未登入而查詢，得到 401 (未授權)錯誤。
![1](images/step01.png)

- 執行登入(一般權限，可以新增、修改，不能刪除)
![1](images/login.png)

- 執行成功後，獲取 JWT Token
![1](images/token_get.png)

- 到認證畫面，輸入Token
![1](images/set_token.png)

- 認證後，可以看到個頁面均已解鎖。不然執行後，都會得到 401 (未授權)錯誤。
![1](images/authed.png)

- 驗證GET功能，OK。
![1](images/get_ok.png)

- 驗證POST功能，OK。
![1](images/post_ok.png)

- 驗證GET{id} 功能(讀取指定ID客戶資料)，OK。
![1](images/get_id_ok.png)

- 驗證PUT{id} 功能(修改指定ID客戶資料)，OK。
![1](images/put_ok.png) 

- 再次重新讀取所有客戶資料
![1](images/get_after_put.png)

- 執行DELETE (刪除指定ID客戶資料)，會得到 401 (未授權)錯誤，因為權限不足。
![1](images/delete_not_authrized.png)

- 改用admin登入 (登入成功後，Token 要用新值重新認證)
![1](images/login_use_admin.png)

- 再次執行DELETE ，OK。
![1](images/delete_ok.png)
