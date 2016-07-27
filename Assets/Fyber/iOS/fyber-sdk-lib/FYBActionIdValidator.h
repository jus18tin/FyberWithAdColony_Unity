//
//
// Copyright (c) 2015 Fyber. All rights reserved.
//
//

#import <Foundation/Foundation.h>

FOUNDATION_EXPORT NSString *const FYBExceptionInvalidActionId;

@interface FYBActionIdValidator : NSObject

+ (BOOL)validate:(NSString *)actionId reasonForInvalid:(NSString **)reason;

+ (void)validateOrThrow:(NSString *)actionId;

@end
