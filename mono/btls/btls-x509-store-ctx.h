//
//  btls-x509-store-ctx.h
//  MonoBtls
//
//  Created by Martin Baulig on 3/3/16.
//  Copyright © 2016 Xamarin. All rights reserved.
//

#ifndef __btls__btls_x509_store_ctx__
#define __btls__btls_x509_store_ctx__

#include <stdio.h>
#include <btls-ssl.h>
#include <btls-x509-chain.h>
#include <btls-x509-name.h>
#include <btls-x509-store.h>
#include <btls-x509-verify-param.h>

MonoBtlsX509StoreCtx *
mono_btls_x509_store_ctx_from_ptr (X509_STORE_CTX *ptr);

MonoBtlsX509StoreCtx *
mono_btls_x509_store_ctx_new (void);

MonoBtlsX509StoreCtx *
mono_btls_x509_store_ctx_up_ref (MonoBtlsX509StoreCtx *ctx);

int
mono_btls_x509_store_ctx_free (MonoBtlsX509StoreCtx *ctx);

int
mono_btls_x509_store_ctx_get_error (MonoBtlsX509StoreCtx *ctx, const char **error_string);

int
mono_btls_x509_store_ctx_get_error_depth (MonoBtlsX509StoreCtx *ctx);

MonoBtlsX509Chain *
mono_btls_x509_store_ctx_get_chain (MonoBtlsX509StoreCtx *ctx);

X509 *
mono_btls_x509_store_ctx_get_current_cert (MonoBtlsX509StoreCtx *ctx);

X509 *
mono_btls_x509_store_ctx_get_current_issuer (MonoBtlsX509StoreCtx *ctx);

void
mono_btls_x509_store_ctx_test (MonoBtlsX509StoreCtx *ctx);

int
mono_btls_x509_store_ctx_init (MonoBtlsX509StoreCtx *ctx,
				   MonoBtlsX509Store *store, MonoBtlsX509Chain *chain);

int
mono_btls_x509_store_ctx_set_param (MonoBtlsX509StoreCtx *ctx, MonoBtlsX509VerifyParam *param);

X509 *
mono_btls_x509_store_ctx_get_by_subject (MonoBtlsX509StoreCtx *ctx, MonoBtlsX509Name *name);

int
mono_btls_x509_store_ctx_verify_cert (MonoBtlsX509StoreCtx *ctx);

MonoBtlsX509VerifyParam *
mono_btls_x509_store_ctx_get_verify_param (MonoBtlsX509StoreCtx *ctx);

MonoBtlsX509Chain *
mono_btls_x509_store_ctx_get_untrusted (MonoBtlsX509StoreCtx *ctx);

#endif /* defined(__btls__btls_x509_store_ctx__) */

