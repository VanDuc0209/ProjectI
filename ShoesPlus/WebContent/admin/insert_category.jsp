<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Thêm danh mục</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Copyright" content="arirusmanto.com">
<meta name="description" content="Admin MOS Template">
<meta name="keywords" content="Admin Page">
<meta name="author" content="Dzewyy">
<meta name="language" content="Vietnamese">

<link rel="shortcut icon" href="stylesheet/img/devil-icon.png"> <!--Pemanggilan gambar favicon-->
<c:set var="root" value="${pageContext.request.contextPath}"/>
<link rel="stylesheet" type="text/css" href="${root}/admin/mos-css/mos-style.css"> <!--pemanggilan file css-->
</head>
<body>
        <%
            String error = "";
            if(request.getParameter("error")!=null){
                error = (String) request.getParameter("error");
            }
        %>
	
	<jsp:include page="header.jsp"></jsp:include>
	
	<div id="wrapper">
		<jsp:include page="menu.jsp"></jsp:include>
		
	<div id="rightContent">
	<h3>Thêm danh mục</h3>
		<form action="CRUD" method="POST">
			<table width="95%">
				<tr>
					<td width="125px"><b>Tên danh mục</b></td>
					<td><input type="text" class="pendek" name="categoryName"><%=error%></td>
				</tr>
				<tr><td></td><td>
					<input type="hidden" name="command" value="insertCategory">
					<input type="submit" class="button" value="Lưu">
				</td></tr>
			</table>
		</form>
	</div>
	<div class="clear"></div>		
		
		<jsp:include page="footer.jsp"></jsp:include>
	</div>
</body>
</html>